using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleXml
    : IText
{
    public string Text =>
        $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}" +
        $"<Circle>{Environment.NewLine}" +
        $"  <TextFlag>black</TextFlag>{Environment.NewLine}" +
        $"  <Context>Physic</Context>{Environment.NewLine}" +
        $"  <Color>{Environment.NewLine}" +
        $"    <A>0</A>{Environment.NewLine}" +
        $"    <R>0</R>{Environment.NewLine}" +
        $"    <G>0</G>{Environment.NewLine}" +
        $"    <B>0</B>{Environment.NewLine}" +
        $"    <ScA>0</ScA>{Environment.NewLine}" +
        $"    <ScR>0</ScR>{Environment.NewLine}" +
        $"    <ScG>0</ScG>{Environment.NewLine}" +
        $"    <ScB>0</ScB>{Environment.NewLine}" +
        $"  </Color>{Environment.NewLine}" +
        $"  <MassCenter>{Environment.NewLine}" +
        $"    <X>10</X>{Environment.NewLine}" +
        $"    <Y>10</Y>{Environment.NewLine}" +
        $"  </MassCenter>{Environment.NewLine}" +
        $"  <Velocity>{Environment.NewLine}" +
        $"    <X>0</X>{Environment.NewLine}" +
        $"    <Y>0</Y>{Environment.NewLine}" +
        $"  </Velocity>{Environment.NewLine}" +
        $"  <IsColorFilled>True</IsColorFilled>{Environment.NewLine}" +
        $"  <Mass>10</Mass>{Environment.NewLine}" +
        $"  <RelativeImagePath>Images\\ball8.bmp</RelativeImagePath>{Environment.NewLine}" +
        $"  <Radius>20</Radius>{Environment.NewLine}" +
        $"</Circle>";
}