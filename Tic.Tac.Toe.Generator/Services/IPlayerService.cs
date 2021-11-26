namespace Tic.Tac.Toe.Generator.Players
{
    public interface IPlayerService
    {
        string nameDefault{get;set;}
        char marker{get;set;}

        void SetMarker(char choice);
        
    }
}