using System.Text.Json.Serialization;

namespace SPB_Backend.Models
{
    public class Target
    {
        public string bank { get; private set; }
        public string branch { get; private set; }
        public string account { get; private set; }

        [JsonConstructor]
        public Target(string bank, string branch, string account)
        {
            this.bank = bank;
            this.branch = branch;
            this.account = account;
        }
    }

    public class Origin
    {
        public string bank { get; private set; }
        public string branch { get; private set; }
        public string cpf { get; private set; }

        [JsonConstructor]
        public Origin(string bank, string branch, string cpf)
        {
            this.bank = bank;
            this.branch = branch;
            this.cpf = cpf;
        }
    }

    public class Root
    {
        public string @event { get; private set; }
        public Target target { get; private set; }
        public Origin origin { get; private set; }
        public int amount { get; private set; }

        [JsonConstructor]
        public Root(string @event, Target target, Origin origin, int amount)
        {
            this.@event = @event;
            this.target = target;
            this.origin = origin;
            this.amount = amount;
        }
    }
}
