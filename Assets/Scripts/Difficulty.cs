public static class Difficulty 
{
    //difficulty variables
    public static int PlayerMaxHealth { get;  private set; } = 100;
    public static int EnemyMaxHealth { get; private set; } = 100;

    //methods
    public static void SetEasyDifficulty()
    {
        PlayerMaxHealth = 200;
        EnemyMaxHealth = 50;
    }

    public static void SetMediumDifficulty()
    {
        PlayerMaxHealth = 100;
        EnemyMaxHealth = 100;
    }

    public static void SetHardDifficulty()
    {
        PlayerMaxHealth = 50;
        EnemyMaxHealth = 200;
    }

}
