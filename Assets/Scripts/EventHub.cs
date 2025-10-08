


public class EventHub {

    public static System.Action PlayerGameOver;


    public static void RaisePlayerGameOver() {
        PlayerGameOver?.Invoke();
    }
}
