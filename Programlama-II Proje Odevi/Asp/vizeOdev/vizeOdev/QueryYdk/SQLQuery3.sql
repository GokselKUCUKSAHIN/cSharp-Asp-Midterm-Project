SELECT NickName,KitapPuan.KullaniciID,KitapID,Puan FROM dbo.KitapPuan INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapPuan.KullaniciID WHERE KitapPuan.KullaniciID <> 1 ORDER BY KitapID,KitapPuan.KullaniciID,Puan

SELECT KullaniciID,KitapID,Puan FROM dbo.KitapPuan WHERE KullaniciID = 1
SELECT NickName,KitapPuan.KullaniciID,KitapID,Puan FROM dbo.KitapPuan INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapPuan.KullaniciID WHERE KitapPuan.KullaniciID <> 1 ORDER BY KitapID,KitapPuan.KullaniciID,Puan