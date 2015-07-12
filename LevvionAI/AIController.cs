using System;
using System.Collections.Generic;
using System.Xml.Linq;
using LevvionAI.Data;
using LevvionAI.Interfaces;
using LevvionAI.Utility;

namespace LevvionAI
{
    /// <summary>
    /// The AI controller in Mask of Levvion.
    /// </summary>
    public class AIController : IXmlLoadable, IXmlSavable
    {
        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public AIState State { get; private set; }
        /// <summary>
        /// Gets the cooldowns.
        /// </summary>
        /// <value>
        /// The cooldowns.
        /// </value>
        public CooldownManager Cooldowns { get; private set; }

        /// <summary>
        /// Gets the current node.
        /// </summary>
        /// <value>
        /// The current node.
        /// </value>
        public Node CurrentNode { get; private set; }
        /// <summary>
        /// Gets the current duration.
        /// </summary>
        /// <value>
        /// The current duration.
        /// </value>
        public Cooldown CurrentDuration { get; private set; }

        /// <summary>
        /// The circles to be evaluated.
        /// </summary>
        public List<Circle> Circles;
        /// <summary>
        /// The random number generator.
        /// </summary>
        private IRandom _rng;

        /// <summary>
        /// Initializes a new instance of the <see cref="AIController"/> class.
        /// </summary>
        /// <param name="rng">The random number generator.</param>
        public AIController(IRandom rng)
        {
            State = new AIState();
            Cooldowns = new CooldownManager();
            CurrentNode = null;
            Circles = new List<Circle>();
            _rng = rng;
        }

        /// <summary>
        /// Updates via the specified deltatime.
        /// </summary>
        /// <param name="deltatime">The deltatime.</param>
        public void Update(TimeSpan deltatime)
        {
            //Update the cooldowns.
            Cooldowns.Update(deltatime);

            //Check if it's doing something
            if (CurrentDuration == null)
            {
                Evaluate();
            }
            else
            {
                //Interrupt if you can.
                if (CurrentNode.Interruptable)
                {
                    Evaluate();
                }
            }

            //Do duration stuff.
            if (CurrentDuration != null)
            {
                CurrentDuration.Update(deltatime);

                if (CurrentDuration.IsFinished())
                {
                    ClearAction();
                }
            }
        }

        /// <summary>
        /// Evaluates the AI.
        /// </summary>
        private void Evaluate()
        {
            //Evaluate circles in order of priority.
            foreach (var circle in Circles)
            {
                var action = EvaluateCircle(circle);

                if (action != null)
                {
                    SetAction(action);
                    break;
                }
            }
        }

        /// <summary>
        /// Evaluates the circle.
        /// </summary>
        /// <param name="circle">The circle.</param>
        /// <returns></returns>
        private Node EvaluateCircle(Circle circle)
        {
            //Evaluate the circle's condition.
            if (!circle.Condition.IsSatisfied(State))
            {
                return null;
            }

            float rand = 0;

            //Evaluate nodes.
            foreach (var node in circle.Nodes)
            {
                //Check if the node is on cooldown.
                if (Cooldowns.IsOnCooldown(node.Action.ID))
                {
                    continue;
                }

                //Evaluate the node's condition.
                if (!node.Condition.IsSatisfied(State))
                {
                    continue;
                }

                //Evaluate the node's chance.
                rand = _rng.GetFloat(0, 1); //Get a random number.

                if (rand > node.Chance)
                {
                    continue;
                }

                //Check if it's a circle. If it is, recurse it!
                if (node.IsCircle())
                {
                    return EvaluateCircle(node as Circle);
                }

                return node;
            }

            //Check the fallback chance.
            rand = _rng.GetFloat(0, 1); //Get a random number.

            if (rand > circle.Chance)
            {
                return null;
            }

            //If that's good, return the fallback action.
            return circle;
        }

        /// <summary>
        /// Sets the action.
        /// </summary>
        /// <param name="node">The node.</param>
        public void SetAction(Node node)
        {
            CurrentNode = node;
            CurrentDuration = new Cooldown(node.Action.Duration);
            Cooldowns.AddCooldown(node.Action.ID, node.Action.Cooldown);
        }

        /// <summary>
        /// Clears the action.
        /// </summary>
        public void ClearAction()
        {
            CurrentNode = null;
            CurrentDuration = null;
        }

        /// <summary>
        /// Uses XML to initialize the object.
        /// </summary>
        /// <param name="element">The element used for loading.</param>
        public void LoadFromXml(XElement element)
        {
            if (element == null)
            {
                return;
            }
            
            //Handle elements. We are assuming they're all circles.
            foreach (var circleelement in element.Elements())
            {
                var circle = AILoader.CreateNode(circleelement) as Circle;

                if (circle != null)
                {
                    Circles.Add(circle);
                }
            }

            Circles.Sort(); //Sort by priority
            Circles.Reverse(); //Reverse it so higher priority is first.
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public XElement SaveToXml()
        {
            var element = new XElement("ai");

            //Add circles as elements.
            foreach (var circle in Circles)
            {
                element.Add(circle.SaveToXml());
            }

            return element;
        }
    }
}
