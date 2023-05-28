    public class SimpsonCharacter
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Imagen { get; set; }
        public string Ocupacion { get; set; }
    }

public class SimpsonCharacterResponse
{
    public List<SimpsonCharacter> Docs { get; set; }
}
