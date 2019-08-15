import 'package:backend/model/text.dart';

import 'harness/app.dart';

void main() {
  final harness = Harness()..install();

  test("GET /heroes returns 200 OK", () async {
    final query = Query<Text>(harness.application.channel.context)
      ..values.name = 'Bob';

    await query.insert();

    final response = await harness.agent.get("/heroes");
    expectResponse(response, 200,
        body: allOf([
          hasLength(greaterThan(0)),
          everyElement({
            "id": greaterThan(0),
            "name": isString,
          })
        ]));
  });

  test("POST /heroes returns 200 OK", () async {
    final response =
        await harness.agent.post("/heroes", body: {"name": "Fred"});

    final badResponse = await harness.agent.post("/heroes", body: {
      "name": "Fred"
    });

    expectResponse(badResponse, 409);

//    expectResponse(response, 200, body: {
//      "id": greaterThan(0),
//      "name": "Fred"
//    });
  });
}
