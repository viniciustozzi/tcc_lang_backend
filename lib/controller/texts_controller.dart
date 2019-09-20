import 'dart:async';

import 'package:aqueduct/aqueduct.dart';
import 'package:backend/model/text.dart';

class TextsController extends ResourceController {
  TextsController(this.context);

  final ManagedContext context;

  @Operation.get()
  Future<Response> getTexts({@Bind.query('title') String title}) async {
    final query = Query<Text>(context);
    if (title != null) {
      query.where((h) => h.title).contains(title, caseSensitive: false);
    }

    final texts = await query.fetch();
    return Response.ok(texts);
  }

  @Operation.get('id')
  Future<Response> getTextByID(@Bind.path('id') int id) async {
    final query = Query<Text>(context)..where((h) => h.id).equalTo(id);

    final text = await query.fetchOne();

    if (text == null) {
      return Response.notFound();
    }

    return Response.ok(text);
  }

  @Operation.post()
  Future<Response> createText(@Bind.body(ignore: ["id"]) Text text) async {
    final query = Query<Text>(context)..values = text;

    final insertedText = await query.insert();

    return Response.ok(insertedText);
  }
}
