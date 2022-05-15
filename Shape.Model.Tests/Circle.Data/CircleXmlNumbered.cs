using Xml.Generator;

namespace Shape.Model.Tests;

public class CircleXmlNumbered
    : IText
{
    public string Text =>
        $"01	|<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}" +
        $"02	|<Circle>{Environment.NewLine}" +
        $"03	|  <TextFlag>black</TextFlag>{Environment.NewLine}" +
        $"04	|  <Context>Physic</Context>{Environment.NewLine}" +
        $"05	|  <Color>{Environment.NewLine}" +
        $"06	|    <A>0</A>{Environment.NewLine}" +
        $"07	|    <R>0</R>{Environment.NewLine}" +
        $"08	|    <G>0</G>{Environment.NewLine}" +
        $"09	|    <B>0</B>{Environment.NewLine}" +
        $"10	|    <ScA>0</ScA>{Environment.NewLine}" +
        $"11	|    <ScR>0</ScR>{Environment.NewLine}" +
        $"12	|    <ScG>0</ScG>{Environment.NewLine}" +
        $"13	|    <ScB>0</ScB>{Environment.NewLine}" +
        $"14	|  </Color>{Environment.NewLine}" +
        $"15	|  <MassCenter>{Environment.NewLine}" +
        $"16	|    <X>10</X>{Environment.NewLine}" +
        $"17	|    <Y>10</Y>{Environment.NewLine}" +
        $"18	|  </MassCenter>{Environment.NewLine}" +
        $"19	|  <Velocity>{Environment.NewLine}" +
        $"20	|    <X>0</X>{Environment.NewLine}" +
        $"21	|    <Y>0</Y>{Environment.NewLine}" +
        $"22	|  </Velocity>{Environment.NewLine}" +
        $"23	|  <IsColorFilled>True</IsColorFilled>{Environment.NewLine}" +
        $"24	|  <Mass>10</Mass>{Environment.NewLine}" +
        $"25	|  <RelativeImagePath>Images\\ball8.bmp</RelativeImagePath>{Environment.NewLine}" +
        $"26	|  <Radius>20</Radius>{Environment.NewLine}" +
        $"27	|</Circle>";
}