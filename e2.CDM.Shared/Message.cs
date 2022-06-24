using System;
using System.Collections.Generic;
using System.Text;

namespace e2.CDM.Lib
{

  public enum MessageType
  {
    AppMsg = 1,
    Notification = 2,
    UserMsg = 3,
    AlarmMsg = 4
  }
  public enum SynOperation
  {
    Item = 1,
    Customer = 2,
    Inventory = 3,
    Campaign = 4,
    Category = 5,
    Sales=6,
    AppClose=7,
    AppUpdate=8,
    ItemReferences = 9,
    SEOPage = 10,
    NewWebOrder = 11,
    TillRegister = 12,
    ItemDescSchema = 13,
    None = 0,
  }
  public class Message
  {
    public MessageType MessageType { get; set; }
    public SynOperation SynOperation { get; set; }
    public string FromUser { get; set; }
    public string ToUser { get; set; }
    public string Note { get; set; }
    public bool IsForceFull { get; set; }
    public Message()
    {

    }
    public Message(MessageType MessageType,  string FromUser, string Note="", string ToUser="", bool IsForceFull=false, SynOperation SynOperation= SynOperation.None)
    {
      this.MessageType = MessageType;
      this.SynOperation = SynOperation;
      this.FromUser = FromUser;
      this.ToUser = ToUser;
      this.Note = Note;
      this.IsForceFull = IsForceFull;
    }

    public string ConvertToString()
    {
     return  Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }
    public static Message StringToMessage(string MessageStr)
    {
      try
      {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(MessageStr);
      }
      catch(Exception ex)
      {
        return new Message();
      }
    }
    public static Message CreateMsg(MessageType MessageType, string FromUser, string Note = "", string ToUser = "", bool IsForceFull = false, SynOperation SynOperation = SynOperation.None)
    {
      Message message = new Message(MessageType, FromUser, Note, ToUser, IsForceFull, SynOperation);
      return message;
    }

  }
}
