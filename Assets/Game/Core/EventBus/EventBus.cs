// Приклад: підписка на подію бою   
eventBus.Subscribe<CombatStartedEvent>(e => audioService.PlayMusic(musicConfig.bossTheme));
eventBus.Subscribe<CombatEndedEvent>(e => audioService.PlayMusic(musicConfig.mainMenuTheme));