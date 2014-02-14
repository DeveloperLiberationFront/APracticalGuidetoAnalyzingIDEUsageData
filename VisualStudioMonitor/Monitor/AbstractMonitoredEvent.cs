using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Monitor
{
    
    [XmlInclude(typeof(MonitoredCommandEvent))]
    [XmlRoot(ElementName = "MonitoredEvent", Namespace = "http://Monitor")]
    public abstract class AbstractMonitoredEvent
    {
        /// <summary>
        /// Default constructor to use in serialization
        /// </summary>
        protected AbstractMonitoredEvent()
        {

        }

        /// <summary>
        /// User friendly event name used for recording in logs
        /// </summary>
        /// 
        public String EventName { get; set; }

        /// <summary>
        /// Configured classification for the log
        /// </summary>
        public String Classification { get; set; }

        /// <summary>
        /// Stores information related to artifacts such as window titles active during the event
        /// </summary>
        public String ArtifactReference { get; set; }

        #region event handler registration and disposal
        public void ToLog()
        {
            DataRecorder.WriteLog(String.Join(",", System.DateTime.UtcNow.ToString("u"), this.EventName, this.Classification));
        }

        public virtual bool RegisterEventForMonitoring(object dte)
        {
            return false;
        }

        protected bool isDisposed;
        public void Dispose()
        {

            this.Dispose(true);

            //GC.SuppressFinalize(this);

        }

        /// <summary>
        /// Remove the event from the handler list
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            //TODO: Deregister each event handler in this class for the implementation of this class
            // if (eventTypeObject != null) eventTypeObject.AfterExecute -= OnEvent;
            this.isDisposed = true;
        }
        #endregion
    }
}
