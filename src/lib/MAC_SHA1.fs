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

module MAC_SHA1

open Bytes
open TLSConstants
open TLSInfo
open Error

type text = bytes
type tag = bytes
type keyrepr = bytes
type key = {k:keyrepr}

// for concreteness; the rest of the module is parametric in a
let a = MA_HMAC(SHA)

#if ideal // We maintain a table of MACed plaintexts
type entry = epoch * text * tag
let log:entry list ref=ref []
let rec tmem (e:epoch) (t:text) (xs: entry list) =
  match xs with
      [] -> false
    | (e',t',m)::res when e = e' && t = t' -> true
    | (e',t',m)::res -> tmem e t res
#endif

let Mac (ki:epoch) key t =
    let m = HMAC.MAC a key.k t in
    #if ideal // We log every authenticated texts, with their index and resulting tag
    log := (ki, t, m)::!log;
    #endif
    m

let Verify (ki:epoch) key t m =
    HMAC.MACVERIFY a key.k t m
    #if ideal // We use the log to correct any verification errors
    && tmem ki t !log
    #endif

let GEN (ki:epoch) = {k= Nonce.mkRandom (macKeySize(a))}
