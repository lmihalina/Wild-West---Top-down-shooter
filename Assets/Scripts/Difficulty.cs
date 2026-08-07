public static class Difficulty 
{
    //difficulty variables
    public static int PlayerMaxHealth { get;  private set; } = 150;
    public static int EnemyMaxHealth { get; private set; } = 100;
    public static float EnemyVelocity { get; private set; } = 2.5f;
    public static float EnemyShootingCooldown { get; private set; } = 1.5f;
    public static float EnemyDetectionRange { get; private set; } = 6f;
    public static int EnemyCount { get; private set; } = 8;
    public static int WhiskeyCount { get; private set; } = 4;

    //methods
    public static void SetEasyDifficulty()
    {
        PlayerMaxHealth = 200;
        EnemyMaxHealth = 50;
        EnemyVelocity = 2f;
        EnemyShootingCooldown = 2f;
        EnemyDetectionRange = 4f;
        EnemyCount = 6;
        WhiskeyCount = 5;
    }

    public static void SetMediumDifficulty()
    {
        PlayerMaxHealth = 150;
        EnemyMaxHealth = 100;
        EnemyVelocity = 2.5f;
        EnemyShootingCooldown = 1.5f;
        EnemyDetectionRange = 6f;
        EnemyCount = 8;
        WhiskeyCount = 4;
    }

    public static void SetHardDifficulty()
    {
        PlayerMaxHealth = 100;
        EnemyMaxHealth = 150;
        EnemyVelocity = 3f;
        EnemyShootingCooldown = 1f;
        EnemyDetectionRange = 8f;
        EnemyCount = 10;
        WhiskeyCount = 3;
    }
}
