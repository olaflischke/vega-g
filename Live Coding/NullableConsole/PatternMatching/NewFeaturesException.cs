using System.Runtime.Serialization;

namespace PatternMatching
{
    [Serializable]
    internal class NewFeaturesException : Exception
    {
        public NewFeaturesException()
        {
        }

        public NewFeaturesException(string? message) : base(message)
        {
        }

        public NewFeaturesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NewFeaturesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}