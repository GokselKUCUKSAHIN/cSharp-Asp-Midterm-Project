﻿SELECT KullaniciID,KitapID,Puan FROM dbo.KitapPuan WHERE KullaniciID = 1 ORDER BY KullaniciID,KitapID
SELECT KullaniciID,KitapID,Puan FROM dbo.KitapPuan WHERE KullaniciID <> 1 ORDER BY KullaniciID,KitapID