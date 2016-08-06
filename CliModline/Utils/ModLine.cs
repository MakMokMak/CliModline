using System;

namespace CliModline.Utils
{
    /// <summary>
    /// 改行コードの変更が可能なクラスです。
    /// </summary>
    public class ModLine
    {
        private readonly string _baseData;

        /// <summary>
        /// 改行コードの変更が可能なクラスのインスタンスを生成します。
        /// </summary>
        /// <param name="source">元となる文字列</param>
        public ModLine(string source)
        {
            var flag = NewLineFlag.None; 
            var temp = source;
            if (temp.Contains("\r\n"))
            {
                flag = flag | NewLineFlag.CRLF;
                temp = temp.Replace("\r\n", "\t");
            }
            if (temp.Contains("\n"))
            {
                flag = flag | NewLineFlag.LF;
            }
            if (temp.Contains("\r"))
            {
                flag = flag | NewLineFlag.CR;
            }

            switch (flag)
            {
                case NewLineFlag.None:
                    OriginalKind = NewLineKind.None;
                    break;
                case NewLineFlag.CRLF:
                    OriginalKind = NewLineKind.CRLF;
                    break;
                case NewLineFlag.LF:
                    OriginalKind = NewLineKind.LF;
                    break;
                case NewLineFlag.CR:
                    OriginalKind = NewLineKind.CR;
                    break;
                default:
                    OriginalKind = NewLineKind.Mixed;
                    break;
            }

            // 改行文字を LF にして保持する
            _baseData = source.Replace("\r\n", "\n").Replace("\r", "\n");
        }

        /// <summary>
        /// このインスタンスの生成元文字列の改行コードを取得します。
        /// </summary>
        public NewLineKind OriginalKind { get; }

        /// <summary>
        /// 改行コードが CRLF の文字列を取得します。
        /// </summary>
        /// <returns></returns>
        public string GetCrLf()
        {
            return _baseData.Replace("\n", "\r\n");
        }

        /// <summary>
        /// 改行コードが CR の文字列を取得します。
        /// </summary>
        /// <returns></returns>
        public string GetCr()
        {
            return _baseData.Replace("\n", "\r");
        }

        /// <summary>
        /// 改行コードが LF の文字列を取得します。
        /// </summary>
        /// <returns></returns>
        public string GetLf()
        {
            return _baseData;
        }

        [Flags]
        private enum NewLineFlag
        {
            None = 0,
            CRLF = 1,
            LF = 2,
            CR = 4,
        }
    }

    public enum NewLineKind
    {
        CRLF,
        LF,
        CR,
        Mixed,
        None,
    }
}
