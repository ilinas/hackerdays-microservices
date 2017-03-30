package com.example.bank.impl

import akka.Done
import com.example.bank.api.BankService
import com.lightbend.lagom.scaladsl.api.ServiceCall
import com.lightbend.lagom.scaladsl.persistence.PersistentEntityRegistry

import scala.concurrent.Future

/**
  * Implementation of the HelloService.
  */
class BankServiceImpl(persistentEntityRegistry: PersistentEntityRegistry) extends BankService {

  override def create = ServiceCall { request =>
    // Look up the Hello entity for the given ID.
    //val ref = persistentEntityRegistry.refFor[HelloEntity](id)

    // Tell the entity to use the greeting message specified.
    //ref.ask(UseGreetingMessage(request.message))

    Future.successful(Done)
  }
}
