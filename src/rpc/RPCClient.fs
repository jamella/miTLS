(*
 * Copyright (c) 2012--2013 MSR-INRIA Joint Center. All rights reserved.
 * 
 * This code is distributed under the terms for the CeCILL-B (version 1)
 * license.
 * 
 * You should have received a copy of the CeCILL-B (version 1) license
 * along with this program.  If not, see:
 * 
 *   http://www.cecill.info/licences/Licence_CeCILL-B_V1-en.txt
 *)

module RPCClient

let entry () =
    let s = System.Console.ReadLine () in

    match RPC.doclient s with
    | None   -> Printf.printfn "Failure"
    | Some r -> Printf.printfn "Response: %s" r