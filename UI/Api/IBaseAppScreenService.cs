using Infinity.Base.UI.ViewModels;

namespace Infinity.Base.UI.Api {
	public interface IBaseAppScreenService {
		void RestoreMenuScreen ();
		
		void ShowMenuScreen (BaseAppMenuScreenViewModel viewModel);

		void HideMenuScreen ();
		
		void ShowSettingsScreen (BaseAppSettingsScreenViewModel viewModel);
		
		void HideSettingsScreen ();
		
		void ShowAchievesScreen (BaseAppAchievesScreenViewModel viewModel);
		
		void HideAchievesScreen ();
		
		void ShowScoreScreen (BaseAppScoreScreenViewModel viewModel);
		
		void HideScoreScreen ();
		
		void ShowLoadingScreen (BaseAppLoadingScreenViewModel viewModel);
		
		void HideLoadingScreen ();

		void ShowEnterNameScreen (BaseAppEnterNameViewModel viewModel);

		void HideEnterNameScreen ();

		void ShowPreMatchScreen (BasePreMatchScreenViewModel viewModel);
		
		void HidePreMatchScreen ();
	}
}
