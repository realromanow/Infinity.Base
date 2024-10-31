using Cysharp.Threading.Tasks;

namespace Infinity.Base.Api {
	public interface IGameProvider {
		UniTask StartProvideApplication ();
	}
}
