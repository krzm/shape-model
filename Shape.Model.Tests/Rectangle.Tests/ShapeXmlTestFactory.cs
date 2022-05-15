using Xml.Generator;
using Xunit;

namespace Shape.Model.Tests;

public abstract class ShapeXmlTestFactory<TShape>
    : Factory<IFileTestTemplate<string>>
	{
		private IFilePath _filePath;
		private ISerializer _serializer;
		private TShape _shape;
		private IFileReader _fileReader;
		private ISerializationTestScheme _serializationTestScheme;
		private IText _expectedXml;
		private IFileTestTemplate<string> _test;

		public virtual string FolderName => @"C:\Tests\TestTempFiles";

		public virtual string FileExtension => "xml";

		public abstract string FileName { get; }

		public ShapeXmlTestFactory(IText expectedXml) =>
			_expectedXml = expectedXml ?? throw new ArgumentNullException(nameof(expectedXml));

		protected virtual IFilePath ProduceFilePath() => new FilePath(
			FolderName,
			FileName,
			FileExtension);

		protected virtual ISerializer ProduceSerializer() => new SerializerXml();

		protected abstract TShape ProduceShape();

		protected virtual IFileReader ProduceFileReader() => new TextFileReader(_filePath);

		protected virtual ISerializationTestScheme ProduceSerializationTestScheme() =>
			new SerializationTestScheme<TShape>(
				_serializer,
				_shape,
				_fileReader);

		protected virtual IText ProduceExpectedXml() => _expectedXml;

		protected virtual IFileTestTemplate<string> ProduceTest() =>
			new SerializationTest(
				_filePath,
				_serializationTestScheme,
				_expectedXml);

		public override IFileTestTemplate<string> Order()
		{
			_filePath = ProduceFilePath();
			_serializer = ProduceSerializer();
			_shape = ProduceShape();
			_fileReader = ProduceFileReader();
			_serializationTestScheme = ProduceSerializationTestScheme();
			_expectedXml = ProduceExpectedXml();
			_test = ProduceTest();

			_test.AssertFailEvent += (message) => Assert.True(false, message);
			_test.IsRemovingTempFiles = true;

			return _test;
		}
	}