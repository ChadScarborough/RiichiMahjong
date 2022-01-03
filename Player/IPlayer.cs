using RMU.Globals;

namespace RMU.Player
{
    public interface IPlayer
    {
        int GetScore();
        Enums.Wind GetSeatWind();
        void SetScore(int score);
        void SetSeatWind(ISeatWindState seatWindState);
        void SetPlayerOnLeft(IPlayer player);
        void SetPlayerAcross(IPlayer player);
        void SetPlayerOnRight(IPlayer player);
        IPlayer GetPlayerOnLeft();
        IPlayer GetPlayerAcross();
        IPlayer GetPlayerOnRight();
    }
}