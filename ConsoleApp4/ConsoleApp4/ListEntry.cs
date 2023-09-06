namespace CS_4
{
    public class ListEntry
    {
        public string CollectionName { get; set; }
        public Update EventType { get; set; }
        public string ChangedPropertyName { get; set; }
        public string TextedElementKey { get; set; }

        public ListEntry(string collectionName, Update eventType, string changedPropertyName, string textedElementKey)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedPropertyName = changedPropertyName;
            TextedElementKey = textedElementKey;
        }

        public override string ToString()
        {
            return $"Collection name: {CollectionName}\n" +
                   $"Event type: {EventType}\n" +
                   $"Property caused elements changing: {ChangedPropertyName}\n" +
                   $"Changed element key: {TextedElementKey}\n";
        }
    }
}