using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        CanInfo canInfo = new CanInfo()
        {
            SignalFlag_Max = 100,
            MessageFlag_Max = 50,
            canBus = new CanBus()
            {
                CANMAP = 1,
                Name = "CAN1",
                Braud_normal = 500,
                Braud_data = 2000,
                SamplePoint_normal = 87,
                SamplePoint_data = 80,
                EventDUT = 1,
                TxMessages = new List<Message>()
                {
                    new Message()
                    {
                        Flag = 1,
                        Name = "Message1",
                        ECU = "ECU1",
                        ID = 256,
                        CycleTime = 100,
                        DLC = 8,
                        Extern = 0,
                        CANFD = 0,
                        MultiplexingBit = 0,
                        MultiplexingLength = 0,
                        MultiplexingData = 0,
                        Field = "",
                        signals = new List<Signal>()
                        {
                            new Signal()
                            {
                                Flag = 1,
                                SingalType = 0,
                                Name = "Signal1",
                                Description = "This is signal 1",
                                Unit = 0,
                                BitOrder = 1,
                                Signed = 0,
                                StartBit = 0,
                                BitLength = 8,
                                Resolution = 1,
                                Offset = 0,
                                MinData = 0,
                                MaxData = 255,
                                DefaultData = 0,
                                ChecksumAlgorithm = 0,
                                EnumStrings = new List<EnumTable>()
                                {
                                    new EnumTable()
                                    {
                                        Data = 0,
                                        String = "Off",
                                        Color = 0
                                    },
                                    new EnumTable()
                                    {
                                        Data = 1,
                                        String = "On",
                                        Color = 1
                                    }
                                }
                            },
                            new Signal()
                            {
                                Flag = 2,
                                SingalType = 0,
                                Name = "Signal2",
                                Description = "This is signal 2",
                                Unit = 0,
                                BitOrder = 1,
                                Signed = 0,
                                StartBit = 8,
                                BitLength = 16,
                                Resolution = 1,
                                Offset = 0,
                                MinData = -32768,
                                MaxData = 32767,
                                DefaultData = 0,
                                ChecksumAlgorithm = 0,
                                EnumStrings = new List<EnumTable>()
                                {
                                    new EnumTable()
                                    {
                                        Data = 0,
                                        String = "Low",
                                        Color = 0
                                    },
                                    new EnumTable()
                                    {
                                        Data = 1,
                                        String = "Medium",
                                        Color = 1
                                    },
                                    new EnumTable()
                                    {
                                        Data = 2,
                                        String = "High",
                                        Color = 2
                                    }
                                }
                            }
                        }
                    }
                },
                RxMessages = new List<Message>()
                {
                    new Message()
                    {
                        Flag = 3,
                        Name = "Message2",
                        ECU = "ECU2",
                        ID = 512,
                        CycleTime = 200,
                        DLC = 8,
                        Extern = 0,
                        CANFD = 0,
                        MultiplexingBit = 0,
                        MultiplexingLength = 0,
                        MultiplexingData = 0,
                        Field = "",


                        signals = new List<Signal>()
                        {
                            new Signal()
                            {
                                Flag = 3,
                                SingalType = 0,
                                Name = "Signal3",
                                Description = "This is signal 3",
                                Unit = 0,
                                BitOrder = 1,
                                Signed = 0,
                                StartBit = 0,
                                BitLength = 8,
                                Resolution = 1,
                                Offset = 0,
                                MinData = 0,
                                MaxData = 255,
                                DefaultData = 0,
                                ChecksumAlgorithm = 0,
                                EnumStrings = new List<EnumTable>()
                                {
                                    new EnumTable()
                                    {
                                        Data = 0,
                                        String = "Inactive",
                                        Color = 0
                                    },
                                    new EnumTable()
                                    {
                                        Data = 1,
                                        String = "Active",
                                        Color = 1
                                    }
                                }
                            }

                        }
                    }
                }
            }
        };

        Root root = new Root();
        root.canInfo = canInfo;
        string classXml = XmlSerializeHelper.XmlSerialize(root);
        Console.WriteLine(classXml);
    }
}

[XmlRootAttribute("root", IsNullable = false)]
public class Root
{   
    [XmlElementAttribute("CANDB", IsNullable = false)]
    public CanInfo canInfo { get; set; }
}

public class CanInfo
{
    [XmlAttribute("SignalFlag_Max")]
    public int SignalFlag_Max { get; set; }

    [XmlAttribute("MessageFlag_Max")]
    public int MessageFlag_Max { get; set; }

    [XmlElementAttribute("CANBUS", IsNullable = false)]
    public CanBus canBus { get; set; }

}

public class CanBus
{
    [XmlAttribute("CANMAP")]
    public int CANMAP { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("Braud_normal")]
    public int Braud_normal { get; set; }

    [XmlAttribute("Braud_data")]
    public int Braud_data { get; set; }

    [XmlAttribute("SamplePoint_normal")]
    public int SamplePoint_normal { get; set; }

    [XmlAttribute("SamplePoint_data")]
    public int SamplePoint_data { get; set; }

    [XmlAttribute("EventDUT")]
    public int EventDUT { get; set; }

    [XmlArrayAttribute("TxMessages")]
    public List<Message> TxMessages { get; set; }

    [XmlArrayAttribute("RxMessages")]
    public List<Message> RxMessages { get; set; }
}

[XmlRootAttribute("Message", IsNullable = false)]
public class Message
{
    [XmlAttribute("Flag")]
    public int Flag { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("ECU")]
    public string ECU { get; set; }

    [XmlAttribute("ID")]
    public int ID { get; set; }

    [XmlAttribute("CycleTime")]
    public int CycleTime { get; set; }

    [XmlAttribute("DLC")]
    public int DLC { get; set; }

    [XmlAttribute("Extern")]
    public int Extern { get; set; }

    [XmlAttribute("CANFD")]
    public int CANFD { get; set; }

    [XmlAttribute("MultiplexingBit")]
    public int MultiplexingBit { get; set; }

    [XmlAttribute("MultiplexingLength")]
    public int MultiplexingLength { get; set; }

    [XmlAttribute("MultiplexingData")]
    public int MultiplexingData { get; set; }

    [XmlAttribute("Field")]
    public string Field { get; set; }

    //[XmlArrayAttribute("Signal")]
    public List<Signal> signals { get; set; }
}

[XmlRootAttribute("Signal", IsNullable = false)]
public class Signal
{
    [XmlAttribute("Flag")]
    public int Flag { get; set; }

    [XmlAttribute("SingalType")]
    public int SingalType { get; set; }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }

    [XmlAttribute("Unit")]
    public int Unit { get; set; }

    [XmlAttribute("BitOrder")]
    public int BitOrder { get; set; }

    [XmlAttribute("Signed")]
    public int Signed { get; set; }

    [XmlAttribute("StartBit")]
    public int StartBit { get; set; }

    [XmlAttribute("BitLength")]
    public int BitLength { get; set; }

    [XmlAttribute("Resolution")]
    public int Resolution { get; set; }

    [XmlAttribute("Offset")]
    public int Offset { get; set; }

    [XmlAttribute("MinData")]
    public int MinData { get; set; }

    [XmlAttribute("MaxData")]
    public int MaxData { get; set; }

    [XmlAttribute("DefaultData")]
    public int DefaultData { get; set; }

    [XmlAttribute("ChecksumAlgorithm")]
    public int ChecksumAlgorithm { get; set; }

    [XmlArrayAttribute("EnumStrings")]
    public List<EnumTable> EnumStrings { get; set; }

}

[XmlRootAttribute("EnumString", IsNullable = false)]
public class EnumTable
{
    [XmlAttribute("Data")]
    public int Data { get; set; }

    [XmlAttribute("String")]
    public string String { get; set; }

    [XmlAttribute("Color")]
    public int Color { get; set; }
}

/// <summary>
/// XML序列化公共处理类
/// </summary>
public static class XmlSerializeHelper
{
    /// <summary>
    /// 将实体对象转换成XML
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="obj">实体对象</param>
    public static string XmlSerialize<T>(T obj)
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("将实体对象转换成XML异常", ex);
        }
    }

    /// <summary>
    /// 将XML转换成实体对象
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="strXML">XML</param>
    public static T DESerializer<T>(string strXML) where T : class
    {
        try
        {
            using (StringReader sr = new StringReader(strXML))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(sr) as T;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("将XML转换成实体对象异常", ex);
        }
    }
}

