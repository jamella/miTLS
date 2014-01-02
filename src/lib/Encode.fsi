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

module Encode

open Bytes
open Error
open TLSInfo
open TLSConstants
open Range

#if verify
type preds = | CipherRange of epoch * range * nat
#endif

type plain
val plain: epoch -> LHAEPlain.adata -> nat -> bytes -> plain
val repr:  epoch -> LHAEPlain.adata -> range -> plain -> bytes

val mac: epoch -> MAC.key -> LHAEPlain.adata -> range -> LHAEPlain.plain -> plain
val verify: epoch -> MAC.key -> LHAEPlain.adata -> range -> plain -> LHAEPlain.plain Result
