using System;

namespace Animals
{
    public class Kangaroo : Animal
    {
	private string subtype;
	public string Subtype { get; set; }

        public Kangaroo()
        {
	        base.Diet = "herbivorous";
	        base.Movement = "hopping";
	        base.Reproduction = "having live young in a pouch";
                base.Scientific = "The scientific family name for kangaroos is Macropus. The four main species are: \r\n \t Red (Macropus rufus), \r\n \t Eastern grey (Macropus giganteus), \r\n \t Western grey (Macropus fuliginosus) and \r\n \t Antilopine (Macropus antilopinus)";
                base.Origin = "Kangaroos are native to Australia.";
	        this.Subtype = "marsupial";
        }

        public override void Science()
        {
            Console.WriteLine(Scientific);
        }

        public override void Originate()
        {
            Console.WriteLine(Origin);
        }
    }
}
