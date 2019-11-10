using Level.Model.Cannon;

namespace Level.Cannon
{
    public interface IBulletFactory
    {
        void WarmUp();
        BulletViewModel GetBullet();
    }
}