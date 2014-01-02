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

module RPC

open System

let program () =
    let args = List.ofArray (Environment.GetCommandLineArgs ()) in
        match args with
        | [_; "server"] -> ignore (RPCServer.entry ())
        | [_; "client"] -> RPCClient.entry ()
        | _             -> failwith "usage: RPC [client|server]"

let _ = program ()
