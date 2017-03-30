package com.example.bank.impl

import com.example.bank.api.BankService
import com.lightbend.lagom.scaladsl.api.ServiceLocator
import com.lightbend.lagom.scaladsl.api.ServiceLocator.NoServiceLocator
import com.lightbend.lagom.scaladsl.persistence.cassandra.CassandraPersistenceComponents
import com.lightbend.lagom.scaladsl.server._
import com.lightbend.lagom.scaladsl.devmode.LagomDevModeComponents
import play.api.libs.ws.ahc.AhcWSComponents
import com.softwaremill.macwire._

class BankLoader extends LagomApplicationLoader {

  override def load(context: LagomApplicationContext): LagomApplication =
    new BankApplication(context) {
      override def serviceLocator: ServiceLocator = NoServiceLocator
    }

  override def loadDevMode(context: LagomApplicationContext): LagomApplication =
    new BankApplication(context) with LagomDevModeComponents

  override def describeServices = List(
    readDescriptor[BankService]
  )
}

abstract class BankApplication(context: LagomApplicationContext)
  extends LagomApplication(context)
    with CassandraPersistenceComponents
    with AhcWSComponents {

  // Bind the services that this server provides
  override lazy val lagomServer = LagomServer.forServices(
    bindService[BankService].to(wire[BankServiceImpl])
  )

  // Register the JSON serializer registry
  override lazy val jsonSerializerRegistry = BankSerializerRegistry

  // Register the Hello persistent entity
  //persistentEntityRegistry.register(wire[HelloEntity])
}
