using System.Collections.ObjectModel;
using IMT_Planner_ViewModels.MainViewModels;
using IMT_Planner_ViewModels.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace IMT_Planner_ViewModels.ChronoViewModels;

public class SuperManagerAssignmentViewModel : ObservableObject
{
    private readonly SuperManagerSelectionService _smSelectionService;
    private readonly ChronoSelectionService _chronoSelectionService;

    public SuperManagerAssignmentViewModel(SuperManagerSelectionService smSelectionService, ChronoSelectionService chronoSelectionService)
    {
        _smSelectionService = smSelectionService;
        _chronoSelectionService = chronoSelectionService;
        _chronoSelectionService.CreateChronoSmList(_smSelectionService.SuperManagerCollection.ToList());
        chronoSelectionService.EntityChanged -= EntityChanged;
        chronoSelectionService.EntityChanged += EntityChanged;
    }

    private void EntityChanged()
    {
      OnPropertyChanged(nameof(SuperManagerSECollection));
      OnPropertyChanged(nameof(SuperManagerPECollection));
      OnPropertyChanged(nameof(SuperManagerNVECollection));
      OnPropertyChanged(nameof(IsFilled));
    }

    public ObservableCollection<SuperManagerCardViewModel> SuperManagerSECollection
    {
        get => _chronoSelectionService.UnlockedSESuperManagerCards;
        set
        {
            _chronoSelectionService.UnlockedSESuperManagerCards = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<SuperManagerCardViewModel> SuperManagerPECollection
    {
        get => _chronoSelectionService.UnlockedPESuperManagerCards;
        set
        {
            _chronoSelectionService.UnlockedPESuperManagerCards = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<SuperManagerCardViewModel> SuperManagerNVECollection
    {
        get => _chronoSelectionService.UnlockedNVESuperManagerCards;
        set
        {
            _chronoSelectionService.UnlockedNVESuperManagerCards = value;
            OnPropertyChanged();
            
        }
    }

    public bool IsFilled => SuperManagerPECollection.Any();
    
}