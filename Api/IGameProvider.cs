using Cysharp.Threading.Tasks;

namespace Plugins.Infinity.Base.Api {
	public interface IGameProvider {
		UniTask StartProvideApplication ();
	}
}
