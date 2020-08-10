#pragma warning disable 0414, 1591
#pragma warning disable 1591, 0612, 3021

using System.Collections.Generic;
using System.Linq;
using pb = global::Google.Protobuf;
using scg = global::System.Collections.Generic;

namespace GrpcExampleService
{
  public static partial class QuizeDefinition
  {
  }

  public sealed partial class QuizeMessage : pb::IMessage<QuizeMessage>
  {
    public scg.List<QuestionMessage> Questions
    {
      get => this.QuestionList.ToList();
    }
  }

  public sealed partial class QuestionMessage : pb::IMessage<QuestionMessage>
  {

    public Dictionary<bool, string> AnswersDictionary
    {
      get => this.Answers.ToDictionary(a => a.Key, b => b.Value);
    }
  }
}
