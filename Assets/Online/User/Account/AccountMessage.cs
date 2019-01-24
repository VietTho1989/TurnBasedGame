using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface AccountMessage
{

	Account.Type getType();

	Account makeAccount();

}