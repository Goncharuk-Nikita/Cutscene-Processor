using System.IO;
using System.Xml.Serialization;

public static class XmlConverter  
{
	public static void SerializeAndSave<T>(string path, T serializeObject)
	{
		var serializer = new XmlSerializer(typeof(T));
		using (var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, serializeObject);
		}
	}
}
