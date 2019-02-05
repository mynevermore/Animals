using System;

namespace Animals
{
    public class Emu : Animal
    {
	private string subtype;
	public string Subtype { get; set; }

	public Emu()
        {
	    base.Diet = "herbivorous/insectivorous";
	    base.Movement = "running on 2 legs";
	    base.Reproduction = "laying eggs";
            base.Scientific = "The scientific name for an emu is Dromaius novaehollandiae.";
            base.Origin = "Emus are native to Australia.";
	    this.Subtype = "bird";
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
