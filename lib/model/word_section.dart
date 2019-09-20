import 'package:backend/backend.dart';
import 'package:backend/model/text.dart';

class WordSection extends ManagedObject<_WordSection> implements _WordSection {}

class _WordSection {
  @primaryKey
  int id;

  @Column(unique: false)
  String word;

  @Column(unique: false)
  bool isPressed;

  @Relate(#words)
  Text text;
}