import 'dart:core';

import 'package:backend/model/word_section.dart';

import '../backend.dart';

class Text extends ManagedObject<_Text> implements _Text {}

class _Text {
  @primaryKey
  int id;

  @Column(unique: true)
  String title;

  ManagedSet<WordSection> words;
}