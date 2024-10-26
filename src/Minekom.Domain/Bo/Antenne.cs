namespace Minekom.Domain.Bo
{
    public class Antenne : IBOEntity
    {
        public int Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        //public IEnumerable<TechnologieFrequence> IdTechnologieAntennes;
    }
}
