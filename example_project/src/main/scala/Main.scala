import scala.math._
import BigInt.probablePrime
import scala.util.Random

@main def start: Unit = 
  val num: BigInt = probablePrime(100, Random)
  val str: String = num.toString(36)
  println(str)

var msg = "Bonjour".sorted.apply(3)