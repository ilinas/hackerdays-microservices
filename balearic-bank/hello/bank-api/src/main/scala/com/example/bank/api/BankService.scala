package com.example.bank.api

import akka.{Done, NotUsed}
import com.lightbend.lagom.scaladsl.api.{Service, ServiceCall}
import play.api.libs.json.{Format, Json}

trait BankService extends Service {

//  /**
//    * Example: curl http://localhost:9000/api/hello/Alice
//    */
//  def hello(id: String): ServiceCall[NotUsed, String]

  /**
    * Example: curl -H "Content-Type: application/json" -X POST -d '{"name":
    * "My Savings"}' http://localhost:9000/api/account/create
    */
  def create: ServiceCall[CreateAccountMessage, Done]

  override final def descriptor = {
    import Service._
    named("bank").withCalls(
      pathCall("/api/account/create", create)
    ).withAutoAcl(true)
  }
}

case class CreateAccountMessage(name: String)

object CreateAccountMessage {
  implicit val format: Format[CreateAccountMessage] = Json.format[CreateAccountMessage]
}
