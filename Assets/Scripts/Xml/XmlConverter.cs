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

	public static T Deserialize<T>(string path)
		where T: class
	{
		var serializer = new XmlSerializer(typeof(T));
		using (var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as T;
		}
	}
	
	
	public static T DeserializeFromXml<T>(this string text)
		where T: class
	{
		var serializer = new XmlSerializer(typeof(T));

		using (TextReader reader = new StringReader(text))
		{
			return serializer.Deserialize(reader) as T;
		}
	}
}
