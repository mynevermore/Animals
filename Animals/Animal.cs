using System;

namespace Animals
{
    public abstract class Animal
    {
	private string diet;
	private string movement;
	private string reproduction;
        private string scientific;
        private string origin;

	public string Diet { get; set; }
	public string Movement { get; set; }
	public string Reproduction { get; set; }
        public string Scientific { get; set; }
        public string Origin { get; set; }

	public virtual void Science()
	{
	    Console.WriteLine("The scientific group name for an animal is Animalia");
	}

	public virtual void Originate()
	{
	    Console.WriteLine("As far as we know, animals only come from Earth.");
	}
    }
}
