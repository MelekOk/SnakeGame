# Yılan Oyunu

Bu proje, C# ve .NET kullanılarak geliştirilmiş bir basit yılan oyunudur. Oyuncu, yılanı kontrol ederek yemleri toplar ve büyür. Duvarlara veya kendi bedenine çarparsa oyun sona erer.

## Özellikler

- **Oyuncu Girişi**: Oyuncu adı girilerek oyun başlatılır.
- **Skor Takibi**: Her yem alındığında skor artar ve oyuncunun puanı kaydedilir.
- **Skor Listesi**: Oyun sonunda, tüm oyuncuların skorları ve oynama süreleri gösterilir.
- **Ana Menü**: Oyuna başlama, skorları görme ve çıkış yapma seçenekleri sunulmaktadır.
- **Yılan Hareketi**: Yılan yön tuşları ile kontrol edilir ve ekrandaki yemleri yemeye çalışır.
  
## Kurulum ve Çalıştırma

1. **Projenin Kurulumu**: Bu projeyi Visual Studio veya .NET CLI kullanarak çalıştırabilirsiniz.
   - Visual Studio'da `SnakeGame` projesini açın ve çalıştırın.
   
2. **Oyun Kontrolleri**:
   - **Yön Tuşları**: Yılanı hareket ettirmek için ok tuşlarını kullanın.
   - **Oyun Bitişi**: Duvara veya yılanın kendi vücuduna çarptığınızda oyun sona erecektir.

## Kod Açıklamaları

- **Oyuncu Bilgileri**: Oyuncuların adı, skor ve süre bilgileri `oyuncuBilgileri` dizisinde saklanır.
- **Skor ve Süre Hesaplama**: Yem yenildiğinde skor artar ve oyun sonunda toplam süre kaydedilir.
- **Ekran Çizimi**: `OyunuCiz`, `CerceveCiz`, `YilaniCiz` ve `YemCiz` gibi metodlar oyunun ekran üzerine çizilmesini sağlar.
  
## Oyun İçi Görünüm

Oyun ekranı, skoru ve geçen süreyi gösteren üst kısım ile sınırlı bir alanın içinde hareket eden yılanı içerir. Oyun ilerledikçe yılan uzar ve yemler rastgele konumlarda belirir.

## İletişim

Eğer herhangi bir sorun yaşarsanız veya katkıda bulunmak isterseniz lütfen bana ulaşın.


-------------------------------------------------------------------------------------------------------

# Snake Game

This project is a simple snake game developed using C# and .NET. The player controls the snake to collect food and grow. If the snake hits the walls or its own body, the game ends.

## Features

- **Player Entry**: The game starts after entering the player name.
- **Score Tracking**: Each time food is collected, the score increases, and the player's score is saved.
- **Score List**: At the end of the game, the scores and playtime of all players are displayed.
- **Main Menu**: Options to start the game, view scores, and exit are available.
- **Snake Movement**: The snake is controlled using the arrow keys to eat the food on the screen.
  
## Installation and Running

1. **Project Setup**: You can run this project using Visual Studio or the .NET CLI.
   - Open and run the `SnakeGame` project in Visual Studio.
   
2. **Game Controls**:
   - **Arrow Keys**: Use the arrow keys to move the snake.
   - **Game End**: The game ends if the snake hits a wall or its own body.

## Code Explanations

- **Player Information**: The names, scores, and time information of players are stored in the `oyuncuBilgileri` array.
- **Score and Time Calculation**: The score increases when food is eaten, and the total time is recorded at the end of the game.
- **Screen Drawing**: Methods like `OyunuCiz`, `CerceveCiz`, `YilaniCiz`, and `YemCiz` handle drawing the game on the screen.
  
## In-Game View

The game screen includes the score and elapsed time at the top, with a limited area where the snake moves. As the game progresses, the snake grows, and food appears in random locations.

## Contact

If you encounter any issues or would like to contribute, please feel free to reach out.

