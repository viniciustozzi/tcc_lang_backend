import 'package:aqueduct/managed_auth.dart';

import 'backend.dart';
import 'controller/register_controller.dart';
import 'controller/texts_controller.dart';

import 'model/user.dart';

class BackendChannel extends ApplicationChannel {
  ManagedContext context;
  AuthServer authServer;

  @override
  Future prepare() async {
    logger.onRecord.listen(
        (rec) => print("$rec ${rec.error ?? ""} ${rec.stackTrace ?? ""}"));

    final config = HeroConfig(options.configurationFilePath);
    final dataModel = ManagedDataModel.fromCurrentMirrorSystem();
    final persistentStore = PostgreSQLPersistentStore.fromConnectionInfo(
        config.database.username,
        config.database.password,
        config.database.host,
        config.database.port,
        config.database.databaseName);

    context = ManagedContext(dataModel, persistentStore);

    final authStorage = ManagedAuthDelegate<User>(context);
    authServer = AuthServer(authStorage);
  }

  @override
  Controller get entryPoint {
    final router = Router();

    router.route('/auth/token').link(() => AuthController(authServer));

    router
        .route('/texts/[:id]')
        .link(() => Authorizer.bearer(authServer))
        .link(() => TextsController(context));

    router
        .route('/register')
        .link(() => RegisterController(context, authServer));

    return router;
  }
}

class HeroConfig extends Configuration {
  HeroConfig(String path) : super.fromFile(File(path));

  DatabaseConfiguration database;
}
