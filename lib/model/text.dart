import '../backend.dart';

class Text extends ManagedObject<_Text> implements _Text {}

class _Text {
  @primaryKey
  int id;

  @Column(unique: true)
  String name;

  @Column(unique: false)
  String value;
}