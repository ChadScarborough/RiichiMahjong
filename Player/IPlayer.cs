namespace RMU.Player
{
    public interface IPlayer
    {
        int GetScore();
        PlayerEnums.SeatWinds GetSeatWind();
        void SetScore(int _score);
        void SetSeatWind(ISeatWindState seatWindState);
        void SetPlayerOnLeft(IPlayer player);
        void SetPlayerAcross(IPlayer player);
        void SetPlayerOnRight(IPlayer player);
        IPlayer GetPlayerOnLeft();
        IPlayer GetPlayerAcross();
        IPlayer GetPlayerOnRight();
    }
}