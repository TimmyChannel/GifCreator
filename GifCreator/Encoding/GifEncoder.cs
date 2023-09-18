using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifCreator.Encoding
{
    public class GifEncoder : IDisposable
    {
        //Установка хэдера и констант для GIF файла
        #region Header Constants
        private const string FileType = "GIF";
        private const string FileVersion = "89a";
        private const byte FileTrailer = 0x3b;

        private const int ApplicationExtensionBlockIdentifier = 0xff21;
        private const byte ApplicationBlockSize = 0x0b;
        private const string ApplicationIdentification = "NETSCAPE2.0";

        private const int GraphicControlExtensionBlockIdentifier = 0xf921;
        private const byte GraphicControlExtensionBlockSize = 0x04;

        private const long SourceGlobalColorInfoPosition = 10;
        private const long SourceGraphicControlExtensionPosition = 781;
        private const long SourceGraphicControlExtensionLength = 8;
        private const long SourceImageBlockPosition = 789;
        private const long SourceImageBlockHeaderLength = 11;
        private const long SourceColorBlockPosition = 13;
        private const long SourceColorBlockLength = 768;
        #endregion

        private bool isFirstImage = true;
        readonly private int? width;
        readonly private int? height;
        readonly private int? repeatCount;
        private readonly Stream stream;
        //Время задержки одного кадра 
        public TimeSpan FrameDelay { get; set; }
        public GifEncoder(Stream stream, int? width = null, int? height = null, int? repeatCount = null)
        {
            this.stream = stream;
            this.width = width;
            this.height = height;
            this.repeatCount = repeatCount;
        }

        //Добавление кадра
        public void AddFrame(Image img, int x = 0, int y = 0, TimeSpan? frameDelay = null)
        {
            using var gifStream = new MemoryStream();
            img.Save(gifStream, ImageFormat.Gif);
            if (isFirstImage)
                InitHeader(gifStream, img.Width, img.Height);

            WriteGraphicControlBlock(gifStream, frameDelay.GetValueOrDefault(FrameDelay));
            WriteImageBlock(gifStream, !isFirstImage, x, y, img.Width, img.Height);
        }
        //Если кадра является первым, то мы должны внести в файл базовые метаданные GIF файла
        private void InitHeader(Stream sourceGif, int w, int h)
        {
            WriteString(FileType);
            WriteString(FileVersion);
            WriteShort(width.GetValueOrDefault(w));
            WriteShort(height.GetValueOrDefault(h));
            // Устанавливаем позицию в исходном файле GIF для чтения информации о глобальной цветовой палитре
            sourceGif.Position = SourceGlobalColorInfoPosition;
            // Записываем байт информации о глобальной цветовой палитре в файл
            WriteByte(sourceGif.ReadByte());
            WriteByte(0);
            WriteByte(0);
            WriteColorTable(sourceGif);

            WriteShort(ApplicationExtensionBlockIdentifier);
            WriteByte(ApplicationBlockSize);
            WriteString(ApplicationIdentification);
            WriteByte(3);
            WriteByte(1);
            WriteShort(repeatCount.GetValueOrDefault(0));
            WriteByte(0);
            isFirstImage = false;
        }
        //Данный код читает таблицу цветов из исходного файла GIF и записывает ее в выходной поток в текущей позиции
        private void WriteColorTable(Stream sourceGif)
        {
            sourceGif.Position = SourceColorBlockPosition;
            var colorTable = new byte[SourceColorBlockLength];
            sourceGif.Read(colorTable, 0, colorTable.Length);
            stream.Write(colorTable, 0, colorTable.Length);
        }
        //данный код читает блок графического управления из исходного файла GIF и записывает его в
        //выходной поток в соответствии с определенной структурой и форматом блока графического управления GIF
        private void WriteGraphicControlBlock(Stream sourceGif, TimeSpan frameDelay)
        {
            sourceGif.Position = SourceGraphicControlExtensionPosition;
            var blockhead = new byte[SourceGraphicControlExtensionLength];
            sourceGif.Read(blockhead, 0, blockhead.Length);
            WriteShort(GraphicControlExtensionBlockIdentifier);
            WriteByte(GraphicControlExtensionBlockSize);
            WriteByte(blockhead[3] & 0xf7 | 0x08);
            //Запись задержки кадра в милисекундах
            WriteShort(Convert.ToInt32(frameDelay.TotalMilliseconds / 10));
            WriteByte(blockhead[6]);
            WriteByte(0);
        }
        //Данный код читает заголовок и данные блока изображения из исходного файла GIF и записывает их в
        //выходной поток в соответствии с определенной структурой и форматом блока изображения GIF.
        private void WriteImageBlock(Stream sourceGif, bool includeColorTable, int x, int y, int h, int w)
        {
            sourceGif.Position = SourceImageBlockPosition;
            var header = new byte[SourceImageBlockHeaderLength];
            sourceGif.Read(header, 0, header.Length);
            WriteByte(header[0]);
            WriteShort(x);
            WriteShort(y);
            WriteShort(h);
            WriteShort(w);
            if (includeColorTable)
            {
                sourceGif.Position = SourceGlobalColorInfoPosition;
                WriteByte(sourceGif.ReadByte() & 0x3f | 0x80);
                WriteColorTable(sourceGif);
            }
            else
                WriteByte(header[9] & 0x07 | 0x07);

            WriteByte(header[10]);

            sourceGif.Position = SourceImageBlockPosition + SourceImageBlockHeaderLength;

            var dataLength = sourceGif.ReadByte();
            while (dataLength > 0)
            {
                var imgData = new byte[dataLength];
                sourceGif.Read(imgData, 0, dataLength);

                stream.WriteByte(Convert.ToByte(dataLength));
                stream.Write(imgData, 0, dataLength);
                dataLength = sourceGif.ReadByte();
            }

            stream.WriteByte(0);

        }
        //Записывает в поток байт
        private void WriteByte(int value)
        {
            stream.WriteByte(Convert.ToByte(value));
        }
        //Записывает в поток 2 байта
        private void WriteShort(int value)
        {
            stream.WriteByte(Convert.ToByte(value & 0xff));
            stream.WriteByte(Convert.ToByte((value >> 8) & 0xff));
        }
        //Записывает строку в поток
        private void WriteString(string value)
        {
            stream.Write(value.ToArray().Select(c => (byte)c).ToArray(), 0, value.Length);
        }
        //Метод записывает завершающий байт в поток и выполняет сброс буфера,
        //чтобы убедиться, что все данные были записаны в выходной поток
        public void Dispose()
        {
            WriteByte(FileTrailer);
            stream.Flush();
        }
    }

}
