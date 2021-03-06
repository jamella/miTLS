(*
 * Copyright (c) 2012--2014 MSR-INRIA Joint Center. All rights reserved.
 * 
 * This code is distributed under the terms for the CeCILL-B (version 1)
 * license.
 * 
 * You should have received a copy of the CeCILL-B (version 1) license
 * along with this program.  If not, see:
 * 
 *   http://www.cecill.info/licences/Licence_CeCILL-B_V1-en.txt
 *)

#light "off"

module MAC

open Bytes
open TLSConstants
open TLSInfo

type text = bytes
type tag = bytes

type key

val Mac:    id -> key -> text -> tag
val Verify: id -> key -> text -> tag -> bool

val GEN: id -> key
val LEAK:   id -> key -> bytes
val COERCE: id -> bytes -> key
