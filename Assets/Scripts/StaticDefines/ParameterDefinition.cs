public static class ParameterDefinition{
    public const int PieceHp=100;
    public const float BulletMaxDistance=10f;
    public static int BulletDamage(BulletType bulletType){
        int damage=0;
        switch (bulletType)
        {
            case(BulletType.normal):
                damage=15;
                break;
            case(BulletType.wide):
                damage=5;
                break;
            case(BulletType.bound):
                damage=10;
                break;
            case(BulletType.pierce):
                damage=5;
                break;
        }
        return damage;
    }
}