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

(* Copyright (c) Microsoft Corporation.  All rights reserved.  *)

(* This file provides trivial F# definitions for F7 specification primitives *)

module Pi

type formula = bool
let pred (x:'a) = true
let forall (f:'a -> formula) = true
let exists (f:'a -> formula) = true

let assume x = ()
let expect x = ()
