using Zenject;

namespace DI
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //   Container.Bind<string>().FromInstance("Hello World!");  //тестовый прогон
            //   Container.Bind<Greeter>().AsSingle().NonLazy();
        }
    }
}

//public class Greeter
//{
//    public Greeter(string message)
//    {
//        Debug.Log(message);
//    }
//}