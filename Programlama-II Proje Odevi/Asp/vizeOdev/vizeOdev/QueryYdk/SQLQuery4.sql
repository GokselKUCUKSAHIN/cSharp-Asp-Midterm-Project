

SELECT DISTINCT NickName,KitapOkuma.KullaniciID,KitapID FROM dbo.KitapOkuma INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapOkuma.KullaniciID WHERE KitapOkuma.KullaniciID = 1 ORDER BY KitapID



SELECT DISTINCT NickName,KitapOkuma.KullaniciID,KitapID FROM dbo.KitapOkuma INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapOkuma.KullaniciID WHERE KitapOkuma.KullaniciID <> 1 ORDER BY KitapID