/* *
* @file ITakeDamage.cs
* @author Alec Ege
* @brief An interface to manage objects that take damage
* @date 2024 - 05 - 24
*/

public interface ITakeDamage
{
    /**
    * Interface method to take damage
    * @param value
    * @return void
    */
    void TakeDamage(int value);
}