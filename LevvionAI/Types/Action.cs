using System;
using System.Xml.Linq;
using LevvionAI.Interfaces;

namespace LevvionAI.Types
{
    /// <summary>
    /// An AI action for use in Mask of Levvion.
    /// </summary>
    public class Action : IXmlLoadable, IXmlSavable
    {
        /// <summary>
        /// The action to tell the entity to do.
        /// </summary>
        public string ID;
        /// <summary>
        /// The duration of the action.
        /// </summary>
        public TimeSpan Duration;
        /// <summary>
        /// The cooldown on the action.
        /// </summary>
        public TimeSpan Cooldown;

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        public Action()
        {
            ID = "";
            Duration = new TimeSpan(0);
            Cooldown = new TimeSpan(0);
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

            //Handle attributes
            foreach (var attribute in element.Attributes())
            {
                if (attribute.Name.LocalName.ToStringEquals("id"))
                {
                    ID = attribute.Value;
                    continue;
                }
            }

            //Handle elements
            Duration = LoadTimeFromXml(element.Element("duration"));
            Cooldown = LoadTimeFromXml(element.Element("cooldown"));
        }

        /// <summary>
        /// Converts the object to XML.
        /// </summary>
        /// <returns></returns>
        public XElement SaveToXml()
        {
            var element = new XElement("action");

            //Attributes
            element.Add(new XAttribute("id", ID));
            
            //Elements
            var durationelement = SaveTimeToXml(Duration);
            durationelement.Name = "duration";
            element.Add(durationelement);

            var cooldownelement = SaveTimeToXml(Cooldown);
            cooldownelement.Name = "cooldown";
            element.Add(cooldownelement);

            return element;
        }

        /// <summary>
        /// Loads the time from XML.
        /// </summary>
        /// <param name="element">The element.</param>
        private TimeSpan LoadTimeFromXml(XElement element)
        {
            if (element == null)
            {
                return new TimeSpan(0, 0, 0, 0, 0);
            }

            //Variables
            int days = 0;
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            int milliseconds = 0;

            //Handle attributes
            foreach (var attribute in element.Attributes())
            {
                if (attribute.Name.LocalName.ToStringEquals("days"))
                {
                    int.TryParse(attribute.Value, out days);
                    continue;
                }

                if (attribute.Name.LocalName.ToStringEquals("hours"))
                {
                    int.TryParse(attribute.Value, out hours);
                    continue;
                }

                if (attribute.Name.LocalName.ToStringEquals("minutes"))
                {
                    int.TryParse(attribute.Value, out minutes);
                    continue;
                }

                if (attribute.Name.LocalName.ToStringEquals("seconds"))
                {
                    int.TryParse(attribute.Value, out seconds);
                    continue;
                }

                if (attribute.Name.LocalName.ToStringEquals("milliseconds"))
                {
                    int.TryParse(attribute.Value, out milliseconds);
                    continue;
                }
            }

            return new TimeSpan();
        }

        /// <summary>
        /// Saves the time to XML.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        private XElement SaveTimeToXml(TimeSpan time)
        {
            var element = new XElement("time");
            element.Add(new XAttribute("days", time.Days));
            element.Add(new XAttribute("hours", time.Hours));
            element.Add(new XAttribute("minutes", time.Minutes));
            element.Add(new XAttribute("seconds", time.Seconds));
            element.Add(new XAttribute("milliseconds", time.Milliseconds));
            return element;
        }
    }
}
